package com.softuni.oop.onelevshop;

public abstract class ElectronicsProduct extends Product {
    private int guaranteeInMonths;

    protected ElectronicsProduct(String name, double price, int quantity, AgeRestriction ageRestriction, int guaranteeInMonths) {
        super(name, price, quantity, ageRestriction);
        this.setGuaranteeInMonths(guaranteeInMonths);
    }


    public int getGuaranteeInMonths() {
        return this.guaranteeInMonths;
    }

    protected void setGuaranteeInMonths(int guaranteeInMonths) {
        if (guaranteeInMonths < 0) {
            throw new IllegalArgumentException("Guarantee cannot be a negative value.");
        }

        this.guaranteeInMonths = guaranteeInMonths;
    }

    @Override
    public String toString() {
        return super.toString() + ", warranty = " + this.getGuaranteeInMonths() + " months";
    }
}
