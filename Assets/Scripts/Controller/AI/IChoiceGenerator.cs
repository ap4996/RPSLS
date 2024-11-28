public interface IChoiceGenerator
{
    public object GenerateRandomChoice();

    public object SelectComputerChoice(object rule);
}
