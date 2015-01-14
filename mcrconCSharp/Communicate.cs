using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace mcrconCSharp
{
    class Rcon
    {
        Socket socket;
        int requestIdRandom;

        private bool _ConnectionState;
        public bool ConnectionState
        {
            get { return _ConnectionState; }
            set
            {
                if (value == _ConnectionState)
                    return;
                _ConnectionState = value;
                if (onConnectionAliveChange != null)
                    onConnectionAliveChange(value);
            }
        }
        
        public delegate void ConnectionStateChanged(bool state);
        public event ConnectionStateChanged onConnectionAliveChange;
        
        System.ComponentModel.BackgroundWorker connectionChecker;

        public Rcon(string host, int port, string password)
        {
            ConnectionState = false;

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                System.Net.IPAddress ipaddr = System.Net.IPAddress.Parse(host);

                requestIdRandom = new Random().Next(1, 999999);

                socket.Connect(ipaddr, port);

                Send(PacketType.Login, password);

                var result = ReceiveInner();
                if (result.requestId == -1)
                    throw new RconException("Invalid logon credentials!", RconException.ErrorTypeEnum.LogonError);
            }
            catch (Exception e)
            {

                string errorMsg = String.Empty;
                if (e is SocketException || e is ObjectDisposedException)
                {
                    errorMsg = "Socket error, try reload application!";
                }
                else
                    if (e is ArgumentNullException || e is InvalidOperationException)
                    {
                        errorMsg = "Input error or bussy port, try reload application";
                    }
                    else
                        errorMsg = "Internal error";

                RconException rconEx = new RconException(errorMsg, e, RconException.ErrorTypeEnum.ConnectionError);
                socket = null;
                throw rconEx;
            }

            connectionChecker = new System.ComponentModel.BackgroundWorker();
            connectionChecker.DoWork += ConnectionChecker;
            connectionChecker.WorkerSupportsCancellation = true;
            connectionChecker.RunWorkerAsync();
        }

        ~Rcon()
        {
            if (socket != null)
                socket.Disconnect(true);
            connectionChecker.CancelAsync();
        }

        public bool IsConnectionAlive()
        {
            if (socket == null)
                return false;
            if (!socket.Connected)
                return false;

            try
            {
                if (String.IsNullOrWhiteSpace(ProcessCommand("list")))
                    return false;
            }
            catch
            {
                return false;
            }
            return true;

        }


        private void ConnectionChecker(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(10000);
                if (connectionChecker.CancellationPending)
                    break;
                ConnectionState = IsConnectionAlive();
            }
        }



        public string ProcessCommand(string command)
        {
            Send(command);
            return Receive();
        }

        private void Send(PacketType packetType, string command)
        {
            if (socket == null)
                throw new RconException("Connection must be established before any action!", RconException.ErrorTypeEnum.ConnectionError);
            if (command.StartsWith("/"))
                command = "\n" + command;
            rconstruct packet = new rconstruct
            {
                requestId = requestIdRandom,
                type = packetType,
                payload = command
            };
            int sended = socket.Send(RconStruct.ToBytes(packet), SocketFlags.None);
            if (sended != packet.length + 4)
                throw new RconException("Sended packet is not equal to packet to send!", RconException.ErrorTypeEnum.CommandError);
        }

        public void Send(string command)
        {
            Send(PacketType.Command, command);
        }

        private rconstruct ReceiveInner()
        {
            if (socket == null)
                throw new RconException("Connection must be established before any action!", RconException.ErrorTypeEnum.ConnectionError);

            byte[] buff = new byte[4096];
            int rcvLength = socket.Receive(buff);

            var response = RconStruct.FromBytes(buff);
            if (response.type == PacketType.Command)
                return response;

            if (response.type != PacketType.CommandResponse)
                throw new RconException("Unexpected server message!", RconException.ErrorTypeEnum.CommandError);
            if (response.requestId != requestIdRandom)
                throw new RconException("Receiverd message with wrong Id! Maybe some rcon work in parallel, try restart app.", RconException.ErrorTypeEnum.CommandError);
            string result = response.payload;

            while (response.length + 4 > rcvLength)
            {
                rcvLength += socket.Receive(buff);
                result += RconStruct.FromBytes(buff).payload;
            }

            return new rconstruct
            {
                requestId = response.requestId,
                type = response.type,
                payload = result
            };
        }

        public string Receive()
        {
            return ReceiveInner().payload;
        }
    }

    public class RconException : ApplicationException
    {
        public enum ErrorTypeEnum
        {
            ConnectionError,
            LogonError,
            CommandError,
            UnknownError
        }

        private static string errorMsg = "Unknown error.";
        public ErrorTypeEnum ErrorType { get; set; }

        public RconException()
            : this(errorMsg)
        {

        }

        public RconException(string msg, ErrorTypeEnum type = ErrorTypeEnum.UnknownError)
            : base(msg)
        {
            ErrorType = type;
        }

        public RconException(string msg, Exception inner, ErrorTypeEnum type = ErrorTypeEnum.UnknownError)
            : base(msg, inner)
        {
            ErrorType = type;
        }
    }
}
