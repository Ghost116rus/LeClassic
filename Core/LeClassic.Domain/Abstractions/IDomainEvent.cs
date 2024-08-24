using MediatR;

namespace LeClassic.Domain.Abstractions
{
    public interface IDomainEvent : INotification
    {
        /// <summary>
        /// Обрабатывать событие в транзакции
        /// </summary>
        public bool IsInTransaction { get; }
    }
}
