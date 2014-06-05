// Task 8:	Write a program to read a text file "Input.txt" holding a sequence 
//			of integer numbers, each at a separate line. Print the sum of 
//			the numbers at the console. Ensure you close correctly the file in 
//			case of exception or in case of normal execution. 
//			In case of exception (e.g. the file is missing), print "Error" as a result. 

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class _08_SumNumbersFromATextFile {

	public static void main(String[] args) {
		String fileName = "src/Input.txt";
		long sumOfNumbers = 0;
		try (BufferedReader fileReader = new BufferedReader(new FileReader(fileName));) {
			while (true) {
				String line = fileReader.readLine();
				if (line == null) {
					break;
				}

				sumOfNumbers += Integer.parseInt(line.trim(), 10);
			}
			
			System.out.println(sumOfNumbers);
		} catch (IOException ex) {
			System.out.println("Error");
		}
	}
}
