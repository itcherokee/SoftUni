// Task 2:	Write a program to generate and print all 3-letter words consisting of given set of characters. 
//			For example if we have the characters 'a' and 'b', all possible words will be "aaa", "aab", 
//			"aba", "abb", "baa", "bab", "bba" and "bbb". The input characters are given as string at the first
//			line of the input. Input characters are unique (there are no repeating characters). 

import java.util.Scanner;

public class _02_GenerateThreeLettersWords {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		System.out.print("How many characters you will use [1..3]: ");

		int numberOfChars = reader.nextInt(10);
		if (numberOfChars < 1 || numberOfChars > 3) {
			System.out.println("Invalid number of characters has been entered!");
			return;
		}

		String[] counts = { "first", "second", "third" };
		char[] characters = new char[numberOfChars];
		for (int i = 0; i < numberOfChars; i++) {
			System.out.print("Enter " + counts[i] + " character: ");
			characters[i] = reader.next().trim().charAt(0);
		}

		System.out.println("All possible 3 letters words: ");
		for (int i = 0; i < numberOfChars; i++) {
			for (int j = 0; j < numberOfChars; j++) {
				for (int k = 0; k < numberOfChars; k++) {
					System.out.printf("%s%s%s ", characters[i], characters[j], characters[k]);
				}
			}
		}
	}
}
