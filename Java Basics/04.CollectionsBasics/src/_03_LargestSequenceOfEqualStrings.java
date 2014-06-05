// Task 3:	Write a program that enters an array of strings and finds 
//			in it the largest sequence of equal elements. If several 
//			sequences have the same longest length, print the leftmost 
//			of them. The input strings are given as a single line, 
//			separated by a space. 

import java.util.Scanner;

public class _03_LargestSequenceOfEqualStrings {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		String[] elements = reader.nextLine().split(" ");

		int longestIndex = 0;
		int longestCount = 1;
		int currentCount = 1;
		String currentWord = elements[0];
		for (int index = 1; index < elements.length; index++) {

			if (elements[index].equals(currentWord)) {
				currentCount++;
				if (currentCount > longestCount) {
					longestCount = currentCount;
					longestIndex = index - longestCount + 1;
				}

				continue;
			}

			currentCount = 1;
			currentWord = elements[index];
		}

		for (int i = longestIndex; i < longestIndex + longestCount; i++) {
			System.out.printf("%s ", elements[i]);
		}
	}
}
