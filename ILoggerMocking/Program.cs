using Moq;
using System;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            var moq = new Mock<ILogger>();
            moq.Setup(x => x.Trace("期待してるメッセージ", LogLevel.Info))
                .Verifiable();

            var logger = moq.Object;
            logger.Info("期待してるメッセージ");  // If you comment this, you'll get MoqException.
            moq.Verify();
        }
    }

    public interface ILogger
    {
        void Trace(string message, LogLevel logLevel);
    }

    public static class LoggerExtensions
    {
        public static void Info(this ILogger self, string message)
        {
            self.Trace(message, LogLevel.Info);
        }
    }

    public enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error
    }
}

