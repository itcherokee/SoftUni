// Task 4:	Write a program that finds the smallest of three numbers.

import java.util.Locale;
import java.util.Scanner;

public class SmallestOfThreeNumbers {
	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		System.out.print("Enter three numbers (or more) to find the smallest: ");
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		String[] input = reader.nextLine().split("[ ,]+");
		double smallestNumber = Double.MAX_VALUE;
		for (int index = 0; index < input.length; index++) {
			double number = Double.parseDouble(input[index]);
			if (number < smallestNumber) {
				smallestNumber = number;
			}
		}

		String formatResult = "";
		if (Math.ceil(smallestNumber) == smallestNumber) {
			formatResult = "%.0f";
		} else {
			formatResult = "%s";
		}

		System.out.printf("The smallest number is " + formatResult, smallestNumber);
	}
};
