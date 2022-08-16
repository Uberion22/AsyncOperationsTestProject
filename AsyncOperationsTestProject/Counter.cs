namespace AsyncOperationsTestProject
{
    internal class Counter
    {
        private static int _count;
        private static object _locker = new object();
        private static bool _objectLocked = false;
        private static int _lockTime = 3000;

        public static int GetCount()
        {
            if (_objectLocked)
            {
                Console.WriteLine($"Чтение: {Thread.CurrentThread.Name} ожидает разблокировки записи");
            }
            while (_objectLocked){}

            return _count;
        }

        public static void AddToCount(int value)
        {
            lock (_locker)
            {
                _objectLocked = true;
                Console.WriteLine($"\nЗапись: {Thread.CurrentThread.Name} блокирует значение {_count} на {_lockTime} милисекунды\n");
                Thread.Sleep(_lockTime);
                _count += value;
                _objectLocked = false;
                Console.WriteLine($"\nЗапись: {Thread.CurrentThread.Name} разблокирован, новое значение: {_count}\n");
            } 
        }

        public static void AddToCountTest()
        {
           AddToCount(1);
        }

        public static void GetCountTest()
        {
            var result = GetCount();
            Console.WriteLine($"Чтение: {Thread.CurrentThread.Name} получил результат: {result}");
        }
    }
}
