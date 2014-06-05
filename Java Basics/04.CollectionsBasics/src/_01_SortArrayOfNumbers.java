// Task 1:	Write a program to enter a number n and n integer numbers and sort 
//			and print them. Keep the numbers in array of integers: int[]. 

import java.util.Arrays;
import java.util.Scanner;

public class _01_SortArrayOfNumbers {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		int numbersCount = reader.nextInt(10);
		reader.nextLine();
		int[] numbers = new int[numbersCount];
		String[] numbersInput = reader.nextLine().split(" ");
		for (int i = 0; i < numbersCount; i++) {
			try {
				numbers[i] = Integer.parseInt(numbersInput[i]);
			} catch (Exception e) {
				System.out.println("Invalid number detected in input!");
			}
		}

		Arrays.sort(numbers);
		for (int i = 0; i < numbersCount; i++) {
			System.out.printf("%d ", numbers[i]);
		}

	}
}
