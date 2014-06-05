// Task 11:	Write a program to find the most frequent word in a text 
//			and print it, as well as how many times it appears in 
//			format "word -> count". Consider any non-letter character 
//			as a word separator. Ignore the character casing. If several 
//			words have the same maximal frequency, print all of them 
//			in alphabetical order. 

import java.util.Collections;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;

public class _11_MostFrequesntWord {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		String[] input = reader.nextLine().toLowerCase().split("\\W+");
		Map<String, Integer> words = new TreeMap<String, Integer>();
		for (String word : input) {
			Integer count = 1;
			if (words.containsKey(word)) {
				count = words.get(word) + 1;
			}

			words.put(word, count);
		}

		int maxValue = Collections.max(words.values());
		for (Entry<String, Integer> word : words.entrySet()) {
			if (word.getValue() == maxValue) {
				System.out.println(word.getKey() + " -> " + word.getValue() + " times");
			}
		}
	}

}
