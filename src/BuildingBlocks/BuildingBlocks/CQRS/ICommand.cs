using MediatR;
using System.Data.Common;

namespace BuildingBlocks.CQRS;

public interface ICommand : ICommand<Unit>
{
}

// Słowo kluczowe out w public interface ICommand<out TResponse> oznacza kowariancję –
// czyli pozwala używać bardziej ogólnego typu zamiast dokładnego w kontekście typu wyjściowego
// Umożliwia przypisanie Producer<Derived> do Producer<Base>

// ICommand<Dog> dogCommand;
// ICommand<Animal> animalCommand = dogCommand; // możliwe dzięki `out`
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
