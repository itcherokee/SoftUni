// Task 1: 	Write a program to generate and print all symmetric 
//			numbers in given range [start…end]. A number is 
//			symmetric if its digits are symmetric toward its middle. 
//			For example, the numbers 101, 33, 989 and 5 are symmetric, 
//			but 102, 34 and 997 are not symmetric.

import java.util.Scanner;

public class _01_SymmetricNumbersInRange {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		System.out.print("Enter start of range: ");
		int startRange = reader.nextInt(10);
		System.out.print("Enter end of range: ");
		int endRange = reader.nextInt(10);
		int number = startRange;
		if (startRange > 0 && endRange > 0) {
			System.out.println("Symetric numbers: ");
			while (number <= endRange) {
				if (isSymenticNumber(number)) {
					System.out.printf("%s ", number);
				}

				number++;
			}
		} else {
			System.out.println("Please, do not use negative numbers for range!");
		}
	}

	// Checks does digits of number are symmetric
	private static boolean isSymenticNumber(int number) {
		int numberLength = getNumberLength(number);
		int multiplier = (int) Math.pow(10, numberLength - 1);
		boolean areEqual = true;
		int nextLength = numberLength;
		int currentLength = numberLength;
		numberLength /= 2;
		int leftDigit;
		for (int i = 0; i < numberLength; i++) {
			if (currentLength == nextLength) {
				leftDigit = number / multiplier;
			} else {
				leftDigit = 0;
			}

			int rightDigit = number % 10;
			if (leftDigit != rightDigit) {
				areEqual = false;
				break;
			} else if (currentLength == 0) {
				break;
			}

			number %= multiplier;
			number /= 10;
			nextLength -= 2;
			multiplier = (int) Math.pow(10, nextLength - 1);
			currentLength = getNumberLength(number);
		}

		return areEqual;
	}

	// Calculate the length of number - number of digits
	private static int getNumberLength(int number) {
		return (int) (Math.ceil(Math.log(number + 1) / Math.log(10)));
	}
}
