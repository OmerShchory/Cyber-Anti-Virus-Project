

namespace O2_AV
{
    internal class PortToScan
    {
        private string protocol;
        private string localAddress;
        private string openPort;
        private string state;
        private int pid;
        private string processName;
        private string processPath;

        public PortToScan(string protocol, string localAddress, string openPort, string state, 
            int pid, string processName, string processPath)
        {
            Protocol = protocol;
            LocalAddress = localAddress;
            OpenPort = openPort;
            State = state;
            Pid = pid;
            ProcessName = processName;
            ProcessPath = processPath;
        }

        public string Protocol { get => protocol; set => protocol = value; }
        public string LocalAddress { get => localAddress; set => localAddress = value; }
        public string OpenPort { get => openPort; set => openPort = value; }
        public string State { get => state; set => state = value; }
        public int Pid { get => pid; set => pid = value; }
        public string ProcessName { get => processName; set => processName = value; }
        public string ProcessPath { get => processPath; set => processPath = value; }

        public override string ToString()
        {
            return "Protocol: " + Protocol + " | " + "Local Address: " + LocalAddress + " | " + "Open Port: " + OpenPort + " | " + "State: " + State +
                " | " + "PID: " + Pid + " | " + "Process Name: " + ProcessName;
        }
    }

}
