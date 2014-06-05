// Task 7:	Write a program to find how many times given string appears in given
//			text as substring. The text is given at the first input line. 
//			The search string is given at the second input line. 
//			The output is an integer number. Please ignore the character casing. 

import java.util.Scanner;

public class _07_CountSubstringOccurrences {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		String text = reader.nextLine().toLowerCase();
		String subString = reader.next();
		int counter = 0;
		int position = -1;
		do {
			position = text.indexOf(subString, position + 1);
			if (position > -1) {
				counter++;
			}
		} while (position > -1);

		System.out.println(counter);
	}
}
