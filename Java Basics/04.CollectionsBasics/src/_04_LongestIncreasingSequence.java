// Task 4:	Write a program to find all increasing sequences inside 
//			an array of integers. The integers are given in a single 
//			line, separated by a space. Print the sequences in the 
//			order of their appearance in the input array, each at 
//			a single line. Separate the sequence elements by a space. 
//			Find also the longest increasing sequence and print it
//			at the last line. If several sequences have the same 
//			longest length, print the leftmost of them. 

import java.util.Scanner;

public class _04_LongestIncreasingSequence {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		String[] input = reader.nextLine().split(" ");
		int[] numbers = new int[input.length];
		for (int index = 0; index < input.length; index++) {
			numbers[index] = Integer.parseInt(input[index], 10);
		}

		int longestIndex = 0;
		int longestCount = 1;
		int currentCount = 1;
		int currentNumber = numbers[0];
		System.out.printf("%d ", currentNumber);
		for (int index = 1; index < numbers.length; index++) {
			if (numbers[index] > currentNumber) {
				currentCount++;
				currentNumber = numbers[index];
				System.out.printf("%d ", currentNumber);
				if (currentCount > longestCount) {
					longestCount = currentCount;
					longestIndex = index - longestCount + 1;
				}

				continue;
			}

			currentCount = 1;
			currentNumber = numbers[index];
			System.out.printf(System.getProperty("line.separator") + "%d ", currentNumber);
		}

		System.out.print(System.getProperty("line.separator") + "Longest: ");
		for (int i = longestIndex; i < longestIndex + longestCount; i++) {
			System.out.printf("%d ", numbers[i]);
		}
	}
}
