using System.Diagnostics.CodeAnalysis;

namespace Demo.Application.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {

    }

    public static void ThrowIfNull([NotNull] object? @object)
    {
        if (@object is null)
        {
            throw new NotFoundException(nameof(@object));
        }
    }
}