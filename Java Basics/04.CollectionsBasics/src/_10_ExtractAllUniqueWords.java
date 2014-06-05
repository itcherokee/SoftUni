// Task 10:	At the first line at the console you are given 
//			a piece of text. Extract all words from it and 
//			print them in alphabetical order. Consider each 
//			non-letter character as word separator. Take the 
//			repeating words only once. Ignore the character 
//			casing. Print the result words in a single line, 
//			separated by spaces. 

import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;

public class _10_ExtractAllUniqueWords {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		String[] input = reader.nextLine().toLowerCase().split("\\W+");
		Set<String> words = new TreeSet<>();
		for (String word : input) {
			words.add(word);
		}

		for (String word : words) {
			System.out.printf("%s ", word);
		}

	}

}
