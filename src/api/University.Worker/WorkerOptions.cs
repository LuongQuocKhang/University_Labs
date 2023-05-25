namespace University.Worker
{
    public class WorkerOptions
    {
        /// <summary>
        /// Defines in seconds the frequency of execution
        /// </summary>
        public int ServiceTimer { get; set; }
        /// <summary>
        /// Defines in seconds a slowness we apply in case of idleness when polling 
        /// </summary>
        public int SlowServiceTimer { get; set; }
        /// <summary>
        /// Defines a threshold if it fails too many times in a row
        /// This will stop the service execution
        /// </summary>
        public int MaxNbConsecutiveException { get; set; }
    }
}
