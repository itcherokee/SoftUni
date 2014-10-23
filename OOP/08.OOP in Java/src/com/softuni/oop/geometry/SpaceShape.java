package com.softuni.oop.geometry;

public abstract class SpaceShape extends Shape implements AreaMeasurable, VolumeMeasurable {
    protected SpaceShape(Point3D vertex) {
        super(vertex);
    }

    @Override
    public String toString() {
        StringBuilder output = new StringBuilder();
        output.append(String.format("Volume: %.2f cm3\n", this.getVolume()));
        output.append(String.format("Area: %.2f cm2\n", this.getArea()));
        output.append(String.format("%s\n", super.toString()));

        return output.toString();
    }

}
