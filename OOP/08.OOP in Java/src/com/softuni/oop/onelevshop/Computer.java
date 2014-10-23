package com.softuni.oop.onelevshop;

public class Computer extends ElectronicsProduct {
    private static final int COMPUTER_GUARANTEE = 24;
    private static final int MAXIMAL_PC_COUNT_FOR_DISCOUNT = 1000;

    protected Computer(String name, double price, int quantity, AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction, COMPUTER_GUARANTEE);
    }

    @Override
    public double getPrice() {
        if (this.getQuantity() > MAXIMAL_PC_COUNT_FOR_DISCOUNT) {
            return this.getPriceOfProduct() * 0.95;
        }

        return super.getPriceOfProduct();
    }
}
