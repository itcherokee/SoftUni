// Task 8:	Write a program to count how many sequences of two 
//			equal bits ("00" or "11") can be found in the binary 
//			representation of given integer number n (with overlapping). 

import java.util.HashMap;
import java.util.Locale;
import java.util.Scanner;

public class CountOfEqualPairs {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		System.out.print("Enter a number to count pairs of 00s and 11s in it: ");
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		int number = reader.nextInt(10);
		HashMap<Integer, Integer> result = countBitPairs(number);
		System.out.printf("There are %1$s pairs ('00' - %2$s | '11' - %3$s)",
				result.get(0) + result.get(1), result.get(0), result.get(1));
	}

	private static HashMap<Integer, Integer> countBitPairs(int number) {
		// result.put(0,0);
		// result.put(1, 0);
		int zeroes = 0;
		int ones = 0;
		String numberAsBinary = Integer.toBinaryString(number);
		int previousBit = getBit(number, 0);
		for (int index = 1; index < numberAsBinary.length(); index++) {
			int currentBit = getBit(number, index);
			if (previousBit == 0) {
				if (previousBit == currentBit) {
					zeroes++;
				}
			} else {
				if (previousBit == currentBit) {
					ones++;
				}
			}

			previousBit = currentBit;
		}

		HashMap<Integer, Integer> result = new HashMap<Integer, Integer>(2);
		result.put(0, zeroes);
		result.put(1, ones);
		return result;
	}

	private static int getBit(int number, int position) {
		int mask = 1;
		return (number & (mask << position)) >> position;
	}
}
