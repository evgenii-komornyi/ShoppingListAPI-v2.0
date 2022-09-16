namespace ShoppingListBLL.Validations
{
    public interface IValidatable<T, E>
    {
        List<E> Validate(T request);
    }
}
