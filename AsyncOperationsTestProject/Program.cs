namespace AsyncOperationsTestProject
{
    internal class Program
    {
        const int GetCountStartDelay = 500;
        const int Timeot = 5000;
        
        static void Main()
        {
            //StartThreadsToGetOrSetCounter();
            TestAsyncCaller(3000);
            TestAsyncCaller(7000);
        }

        /// <summary>
        /// Метод для тестирования досупа к переменной статического класса,
        /// реализован через создание потоков(просто для наглядности)
        /// </summary>
        static void StartThreadsToGetOrSetCounter()
        {
            Thread myThread;
            for (int i = 1; i < 25; i++)
            {
                if (i % 4 == 0)
                {
                    myThread = new(Counter.AddToCountTest);
                }
                else
                {
                    Thread.Sleep(GetCountStartDelay);
                    myThread = new(Counter.GetCountTest);
                }
                myThread.Name = $"Поток {i}";
                myThread.Start();
            }
        }

        /// <summary>
        /// Метод демонстрации задачи 2
        /// Ждет результата выполнения AsyncCaller,
        /// принимает в качестве параметра время работы метода.
        /// </summary>
        /// <param name="workTime">Время до завершения работы метода</param>
        private static void TestAsyncCaller(int workTime)
        {
            EventHandler myEventsHandler = new EventHandler(DoSomeWork);
            AsyncCaller ac = new AsyncCaller(myEventsHandler);
            if (ac.Invoke(Timeot, null, new MyEventArgs(workTime)))
            {
                Console.WriteLine("Задача завершена до истечения времени");
            }
            else
            {
                Console.WriteLine("Задача не завершена до истечения времени");
            }
        }

        /// <summary>
        /// Метод имитирующий работу
        /// </summary>
        static void DoSomeWork(object sender, EventArgs e)
        {
            var workTime = ((MyEventArgs)e).WorkTime;
            Console.WriteLine($"Начало работы метода DoSomeWork");
            Thread.Sleep(workTime);
            Console.WriteLine("Конец работы метода DoSomeWork");
        }
    }
}