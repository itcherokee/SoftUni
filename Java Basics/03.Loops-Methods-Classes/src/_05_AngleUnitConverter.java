// Task 5:	Write a method to convert from degrees to radians. Write a method 
//			to convert from radians to degrees. You are given a number n and n 
//			queries for conversion. Each conversion query will consist of 
//			a number + space + measure. Measures are "deg" and "rad". Convert 
//			all radians to degrees and all degrees to radians. Print the results 
//			as n lines, each holding a number + space + measure. Format all numbers 
//			with 6 digit after the decimal point.

import java.util.Scanner;

public class _05_AngleUnitConverter {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		int numberOfConversions = reader.nextInt(10);
		double[] numbers = new double[numberOfConversions];
		String[] measures = new String[numberOfConversions];
		for (int i = 0; i < numberOfConversions; i++) {
			numbers[i] = reader.nextDouble();
			measures[i] = reader.next();
		}

		for (int i = 0; i < numberOfConversions; i++) {
			switch (measures[i]) {
			case "rad":
				System.out.printf("%.6f deg\n", RadianToDegree(numbers[i]));
				break;
			case "deg":
				System.out.printf("%.6f rad\n", DegreeToRadian(numbers[i]));
				break;
			default:
				break;
			}
		}
	}

	private static double DegreeToRadian(double degree) {
		return degree * (Math.PI / 180);
	}

	private static double RadianToDegree(double radian) {
		return radian * (180 / Math.PI);
	}
}
