// Task 6:	Write a program to generate n random hands of 5 different 
//			cards form a standard suit of 52 cards. 

import java.util.Random;
import java.util.Scanner;

public class _06_RandomHandsOfFiveCards {

	static char[] suits = { '\u2663', '\u2666', '\u2665', '\u2660' };
	static String[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		int numberOfHands = reader.nextInt(10);

		for (int i = 0; i < numberOfHands; i++) {
			printHand(generateHand());
		}
	}

	private static void printHand(int[][] hand) {
		for (int i = 0; i < hand.length; i++) {
			System.out.printf("%s%s ", values[hand[i][1]], suits[hand[i][0]]);
		}

		System.out.println();
	}

	private static int[][] generateHand() {
		Random cardGenerator = new Random();
		int[][] hand = new int[5][2];
		boolean isUnique;
		int numberOfCards = 0;
		do {
			isUnique = true;
			int suit = cardGenerator.nextInt(suits.length);
			int value = cardGenerator.nextInt(values.length);

			for (int index = 0; index < numberOfCards; index++) {
				if (hand[index][0] == suit && hand[index][1] == value) {
					isUnique = false;
					break;
				}
			}

			if (isUnique) {
				hand[numberOfCards][0] = suit;
				hand[numberOfCards][1] = value;
				numberOfCards++;
			}
			
		} while (!isUnique || numberOfCards < 5);

		return hand;
	}
}
