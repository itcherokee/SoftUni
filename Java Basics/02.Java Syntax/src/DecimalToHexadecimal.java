// Task 5: 	Write a program that enters a positive integer number num 
//			and converts and prints it in hexadecimal form. You may use 
//			some built-in method from the standard Java libraries. 

import java.util.Locale;
import java.util.Scanner;

public class DecimalToHexadecimal {

	public static void main(String[] args) {
		Locale.setDefault(Locale.ROOT);
		System.out.print("Enter a number to convert to Hex: ");
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		int number = reader.nextInt(10);
		System.out.printf("In Hex (using implicit conversion) the number is: %H", number);
		System.out.println();
		System.out.printf("In HEX (using explicit conversion) the number is: %S", Integer.toHexString(number));
	}
}
