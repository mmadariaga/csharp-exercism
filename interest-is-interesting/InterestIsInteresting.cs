using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0) {
            return 3.213f;
        }

        if (balance < 1000) {
            return 0.5f;
        }

        if (balance < 5000) {
            return 1.621f;
        }

        return 2.475f;
    }

    public static decimal Interest(decimal balance)
    {
        decimal interest = (decimal) (InterestRate(balance) / 100.0f);

        return balance * interest;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        if (balance < 0) {
            return 0;
        }

        decimal amount = balance;
        int years = 0;

        while (true) {
            if (amount >= targetBalance) {
                return years;
            }

            amount += Interest(amount);
            years++;
        }
    }
}
