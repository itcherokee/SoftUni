import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class _09_CombineListOfLetters {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner reader = new Scanner(System.in);
		String[] inputOne = reader.nextLine().toLowerCase().split("\\W+");
		String[] inputTwo = reader.nextLine().toLowerCase().split("\\W+");
		ArrayList<String> lettersOne = new ArrayList<>(Arrays.asList(inputOne));
		ArrayList<String> lettersTwo = new ArrayList<>();
		for (String letter : inputTwo) {
			if (!lettersOne.contains(letter)) {
				lettersTwo.add(letter);
			}
		}

		lettersOne.addAll(lettersTwo);
		for (String letter : lettersOne) {
			System.out.printf("%s ", letter);
		}
	}
}
