// Task 2:	Write a program that enters an array of strings and finds 
//			in it all sequences of equal elements. The input strings 
//			are given as a single line, separated by a space.

import java.util.Scanner;

public class _02_SequencesOfEqualStrings {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		String[] elements = reader.nextLine().split(" ");
		int index = 0;
		while (index < elements.length) {
			System.out.printf("%s ", elements[index]);
			index++;
			if (index < elements.length && !elements[index - 1]
					.equals(elements[index])) {
				System.out.println();
			}
		}
	}
}
