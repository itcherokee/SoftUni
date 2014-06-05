// Task 5: 	Create a simple Java program CurrentDateTime.java to print 
//			the current date and time. 

import java.time.LocalDateTime;

public class CurrentDateTime {
	public static void main(String[] args) {
		LocalDateTime currentTime = LocalDateTime.now();
		String newLine = System.getProperty("line.separator");
		System.out.printf("Current date: %s%sCurrent time: %s",
				currentTime.toLocalDate(), newLine, currentTime.toLocalTime());
	}
}
