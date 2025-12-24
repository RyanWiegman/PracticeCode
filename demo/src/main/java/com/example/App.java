package com.example;

import com.github.kwhat.jnativehook.GlobalScreen;
import com.github.kwhat.jnativehook.NativeHookException;
import com.github.kwhat.jnativehook.keyboard.NativeKeyEvent;
import com.github.kwhat.jnativehook.keyboard.NativeKeyListener;

/**
 * Hello world!
 *
 */
public class App {
    public static void main(String[] args) {
        System.out.println("Hello world");

        try {
            GlobalScreen.registerNativeHook();
            GlobalScreen.addNativeKeyListener(new NativeKeyListener() {

                @Override
                public void nativeKeyTyped(NativeKeyEvent nativeEvent) {
                    System.out.println("char? :: " + nativeEvent.getKeyChar());

                }

                @Override
                public void nativeKeyReleased(NativeKeyEvent nativeEvent) {
                    String keyText = NativeKeyEvent.getKeyText(nativeEvent.getKeyCode());
                    System.out.println("User typed: " + keyText);

                    if (keyText == "Space") {
                        System.out.println("space press...");
                    }
                }

                @Override
                public void nativeKeyPressed(NativeKeyEvent nativeEvent) {
                }
            });
        } catch (NativeHookException e) {
            e.printStackTrace();
        }
    }
}