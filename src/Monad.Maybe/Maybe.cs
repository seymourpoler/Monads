namespace Monad.Maybe;

public static class Maybe<T>
{
    private static IMaybe<T> None => None<T>.Of();

    public static IMaybe<T> Of(T value)
    {
        if (value is null)
        {
            return None<T>.Of();
        }

        return Just<T>.Of(value);
    }
}