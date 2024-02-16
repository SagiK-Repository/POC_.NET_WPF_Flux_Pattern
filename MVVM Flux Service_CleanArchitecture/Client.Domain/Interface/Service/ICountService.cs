namespace Client.Domain.Service;
public interface ICountService
{
    int Increase(int count);
    int Decrease(int count);
}
