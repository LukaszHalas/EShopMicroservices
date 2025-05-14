using MediatR;

namespace BuildingBlocks.CQRS;

public interface ICommandHandler<in TCommand>
    : IRequestHandler<TCommand, Unit>
    where TCommand : ICommand
{
}

// Słowo kluczowe in w C# przy deklaracji typu generycznego oznacza kontrawariancję —
// czyli że typ można zastąpić typem bazowym  w kontekście typy wejściowego
// Umożliwia przypisanie Handler<Base> do Handler<Derived>

// class MyHandler : ICommandHandler<BaseCommand, string> { }
// ICommandHandler<DerivedCommand, string> handler = new MyHandler(); // OK — kontrawariancja

// Jezeli nie ma slowka in oraz out to taki typ byłby traktowany jako inwariantny, czyli:
// ICommandHandler<BaseCommand, TResponse> nie byłby kompatybilny z ICommandHandler<DerivedCommand, TResponse> ani odwrotnie.
public interface ICommandHandler<in TCommand, TResponse> 
    : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
}
