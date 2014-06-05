public class _03_FullHouse {

	public static void main(String[] args) {
		char[] suits = { '\u2663', '\u2666', '\u2665', '\u2660' };
		String[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
		int counter = 0;
		for (int value = 0; value < values.length; value++) {

			for (int i = 0; i < 2; i++) {
				for (int j = i + 1; j < 3; j++) {
					for (int k = j + 1; k < 4; k++) {

						for (int k2 = 0; k2 < 3; k2++) {
							for (int l = k2 + 1; l < 4; l++) {
								int secondValue = value < 12 ? value + 1 : 0;
								System.out.print("( " + values[value] + suits[i] + values[value] + suits[j] + values[value] + suits[k] + ")");
								System.out.println("(" + values[secondValue] + suits[k2] + values[secondValue] + suits[l] + ")");
								counter++;
							}
						}

					}
				}
			}
		}

		System.out.println("Count - " + counter + "(this are without duplicates on different positions)");

	}
}