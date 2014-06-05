// Task 5:	Write a program to count the number of words in given sentence. 
//			Use any non-letter character as word separator.

import java.util.Scanner;

public class _05_CountAllWords {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		String[] words = reader.nextLine().split("\\W+");
		System.out.println(words.length);
	}
}
