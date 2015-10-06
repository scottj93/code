namespace code.matching
{
  public interface IMatchAn<in Item>
  {
    bool matches(Item item);
  }
}