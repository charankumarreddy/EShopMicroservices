
using MediatR;

namespace Common.CQRS;


public interface ICommand : ICommand<Unit>
{
}


public interface ICommand<out TResponce> : IRequest<TResponce>
{
}
