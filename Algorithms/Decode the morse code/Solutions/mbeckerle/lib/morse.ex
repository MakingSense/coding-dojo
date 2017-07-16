defmodule Morse do
  @moduledoc """
  Morse decoder library.
  """

  @words_separator "   "
  @hacked_words_separator " @ "

  @doc """
  Decode.

  ## Examples

      iex> Morse.decode ".... . .-.. .-.. ---"
      "HELLO"

  """
  def decode(morse_code) do
    morse_code
      |> String.replace(@words_separator, @hacked_words_separator)
      |> String.split
      |> Enum.map(fn x -> MorseDictionary.dictionary[x] end)
      |> Enum.join
  end
end
