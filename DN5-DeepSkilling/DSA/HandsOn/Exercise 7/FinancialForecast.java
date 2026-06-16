
public class FinancialForecast {
	public static double predictFutureValue(double currentValue,
            double growthRate,
            int years) {

// Base Case
if (years == 0) {
return currentValue;
}

// Recursive Case
return predictFutureValue(
currentValue * (1 + growthRate),
growthRate,
years - 1
);
}

public static void main(String[] args) {

double presentValue = 10000.0;
double growthRate = 0.10; // 10%
int years = 5;

double futureValue = predictFutureValue(
presentValue,
growthRate,
years
);

System.out.println("Present Value: ₹" + presentValue);
System.out.println("Growth Rate: " + (growthRate * 100) + "%");
System.out.println("Years: " + years);
System.out.println("Predicted Future Value: ₹" + futureValue);
}
}
