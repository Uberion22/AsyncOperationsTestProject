namespace AsyncOperationsTestProject
{
    internal class AsyncCaller
    {
        private readonly EventHandler handler;
        private readonly CancellationTokenSource ts = new CancellationTokenSource();

        public AsyncCaller(EventHandler handler) => this.handler = handler;

        public bool Invoke(int timeout, object sender, MyEventArgs e)
        {
            var result = Task.Run(() => handler.Invoke(sender, e));
            
            return result.Wait(timeout);
        }

    }


}
