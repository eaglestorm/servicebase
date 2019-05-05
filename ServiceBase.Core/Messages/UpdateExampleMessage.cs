using CleanConnect.Common.Contracts;
using MediatR;
using ServiceBase.Core.Model.Context;

namespace ServiceBase.Core.Messages
{
    /// <summary>
    /// Domain event that indicates the example model has been updated.
    /// </summary>
    public class UpdateExampleMessage: IDomainEvent
    {
        /// <summary>
        /// What ever info we need in the message.
        /// </summary>
        public ExampleModel Model { get; set; }
    }
}