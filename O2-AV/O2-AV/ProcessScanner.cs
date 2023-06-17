using System.Management;

namespace O2_AV
{
    internal class ProcessScanner
    {
        AVEngine engine;
        public ProcessScanner(AVEngine engine) 
        {
            this.engine = engine;
        }

        public void Start()
        {
            // Set up a query to retrieve instances of the Win32_Process class
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM " +
                "__InstanceCreationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_Process'");

            // Create a new management scope
            ManagementScope scope = new ManagementScope("\\\\.\\root\\CIMV2");

            // Create a new event watcher
            ManagementEventWatcher watcher = new ManagementEventWatcher(scope, query);

            // Set up the event handler
            watcher.EventArrived += (s, e) =>
            {
                // Get the process name and ID
                ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
                string processName = (string)instance["Name"];
                uint processId = (uint)instance["ProcessId"];
                string executablePath = (string)instance["ExecutablePath"];

                // Queue to the AVEngine the Process exe File              
                engine.QueueFileForScan(new FileToScan(executablePath, 
                    "Reactive Process Scan | Process Name: " 
                    + processName + " | PID: " + processId));
            };

            // Start the watcher
            watcher.Start();
        }

    }
}
