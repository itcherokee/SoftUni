// Task 12:	We are given a sequence of N playing cards from a standard deck. 
//			The input consists of several cards (face + suit), separated by 
//			a space. Write a program to calculate and print at the console 
//			the frequency of each card face in format "card_face -> frequency". 
//			The frequency is calculated by the formula appearances / N and is 
//			expressed in percentages with exactly 2 digits after the decimal 
//			point. The card faces with their frequency should be printed in 
//			the order of the card face's first appearance in the input. 
//			The same card can appear multiple times in the input, but it's face 
//			should be listed only once in the output. 	

import java.util.HashMap;
import java.util.Scanner;
import java.util.TreeMap;

public class _12_CardFrequencies {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		String[] input = reader.nextLine().split("[ \\u2663\\u2666\\u2665\\u2660]+");

		// TreeMap used for storing card's faces and number of appearances
		TreeMap<String, Integer> faces = new TreeMap<String, Integer>();

		// HashMap used to store the position in input of a face
		HashMap<Integer, String> positions = new HashMap<Integer, String>();
		int nextToken = 0;
		for (int index = 0; index < input.length; index++) {
			if (!faces.containsKey(input[index])) {
				positions.put(nextToken++, input[index]);
				faces.put(input[index], 1);
			} else {
				int count = faces.get(input[index]) + 1;
				faces.put(input[index], count);
			}
		}

		for (int index = 0; index < positions.size(); index++) {
			double percentage = faces.get(positions.get(index)) * 100.0 / input.length;
			System.out.printf("%s -> %.2f%%%s",
					positions.get(index), percentage, System.getProperty("line.separator"));
		}
	}
}
