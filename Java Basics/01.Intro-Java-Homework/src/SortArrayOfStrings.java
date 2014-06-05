// Task 8: 	Write a program that enters from the console number n and n strings, 
//			then sorts them alphabetically and prints them.

import java.util.Arrays;
import java.util.Scanner;

public class SortArrayOfStrings {
	public static void main(String[] args) {
		System.out.print("How many strings you will enter (number): ");
		Scanner scanner = new Scanner(System.in);
		int numberOfStrings = scanner.nextInt();
		String[] text = new String[numberOfStrings];
		for (int index = 0; index < numberOfStrings; index++) {
			System.out.printf("Enter %d string: ", index);
			text[index] = scanner.next();
		}

		Arrays.sort(text);
		System.out.println("Sorted list of entered strings:");
		String newLine = System.getProperty("line.separator");
		for (int index = 0; index < numberOfStrings; index++) {
			System.out.printf("%d. %s%s", index + 1, text[index], newLine);
		}
	}
}
