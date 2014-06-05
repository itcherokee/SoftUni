// Task 6:	Write a program to find how many times a word appears in given text. 
//			The text is given at the first input line. The target word is given 
//			at the second input line. The output is an integer number. 
//			Please ignore the character casing. Consider that any non-letter 
//			character is a word separator. 

import java.util.Map;
import java.util.HashMap;
import java.util.Scanner;

public class _06_CountSpecifiedWord {
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		String[] input = reader.nextLine().toLowerCase().split("\\W+");
		Map<String, Integer> words = new HashMap<String, Integer>();
		for (String word : input) {
			Integer count = 1;
			if (words.containsKey(word)) {
				count = words.get(word) + 1;
			}

			words.put(word, count);
		}

		String word = reader.next();
		int result = 0;
		if (words.containsKey(word)) {
			result = words.get(word);
		}

		System.out.println(result);
	}
}
