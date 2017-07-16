defmodule MorseTest do
  use ExUnit.Case
  doctest Morse

  test "decode translates encoded messages" do
    assert Morse.decode(".... . -.--   .--- ..- -.. .") == "HEY JUDE"
  end
end
