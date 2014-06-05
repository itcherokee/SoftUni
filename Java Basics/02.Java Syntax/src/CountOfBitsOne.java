// Task 7:	Write a program to calculate the count of bits 1 in the binary 
//			representation of given integer number n.

import java.util.Locale;
import java.util.Scanner;

public class CountOfBitsOne {
	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		System.out.print("Enter an integer to count 1s bits: ");
		int number = reader.nextInt();

		String binary = Integer.toBinaryString(number).replace(' ', '0');
		while (binary.length() < 16) { 
			binary = "0" + binary;
		}
		
		int numberOfOneBits = Integer.bitCount(number);
		System.out.printf("binary presentation = %s | 1s bits = %s", binary, numberOfOneBits);
	}

}
