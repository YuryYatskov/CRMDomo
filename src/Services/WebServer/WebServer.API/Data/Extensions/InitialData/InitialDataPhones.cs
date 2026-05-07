namespace WebServer.API.Data.Extensions;

public static partial class InitialData
{
    public static IEnumerable<Phone> GetPreconfiguredPhones(
        IEnumerable<Counterparty> counterparties)
    {
        Random rnd = new();
        Counterparty[] shuffledList = [.. counterparties.OrderBy(x => rnd.Next())];

        int i = -1;

        List<Phone> phoneList = [];

        foreach (Counterparty counterparty in shuffledList)
        {
            // First
            long number = 380441002001 + ++i;
            Phone phone = new()
            {
                Id = Guid.NewGuid(),
                Number = $"+{number}",
                CounterpartyId = counterparty.Id,
                Counterparty = counterparty,
            };

            phoneList.Add(phone);

            // Second
            number = 380671003001 + ++i;
            phone = new()
            {
                Id = Guid.NewGuid(),
                Number = $"+{number}",
                CounterpartyId = counterparty.Id,
                Counterparty = counterparty,
            };

            phoneList.Add(phone);

            // Three
            number = 380501005001 + ++i;
            phone = new()
            {
                Id = Guid.NewGuid(),
                Number = $"+{number}",
                CounterpartyId = counterparty.Id,
                Counterparty = counterparty,
            };
            phoneList.Add(phone);  
        }

        return phoneList;
    }
}
