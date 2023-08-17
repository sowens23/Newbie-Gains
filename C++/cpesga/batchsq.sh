#!/bin/bash
#Let's declare some values
tegraout="~/cpesgafiles/tegraout/"
guppyout="~/cpesgafiles/guppyout/"
guppyrun="~/cpesgafiles/batchtest/"
today=$(date "+%Y%m%d")
waittime="1"
tegrainterval="5000"

# LOOP set {1-5}
for ((folder=1; folder<=5; folder++)); do
  for ((mode=1; mode<=3; mode++)); do
    # LOOP Fast/Hac/Sup
    if [[ "$mode" == "1" ]]; then
      model="fast"
    fi
    if [[ "$mode" == "2" ]]; then
      model="hac"
    fi
    if [[ "$mode" == "3" ]]; then
      model="sup"
    fi
	echo "$today-set$folder-$mode"
  done
done


# Start tegrastats in the background and redirect output to a file
rm -rf "$logfile"
tegrastats --interval $tegrainterval --logfile "$logfile" &

# Store the PID of the tegrastats process
tegrastats_pid=$!

#pause
echo "waiting $waittime"
sleep $waittime

# Run guppy (replace with your guppy command)
rm -rf "$guppyoutput"
guppy_basecaller -i ./batchtest -s ./"$today"-gout -c dna_r9.4.1_450bps_fast.cfg --device cuda:all     --chunk_size 500 --chunks_per_runner 50 > "guppy_output.txt"

guppytime=grep "samples/s:" "$guppy_output"
guppytime >> $logfile

#pause
echo "waiting $waittime"
sleep $waittime

# Once guppy is finished, terminate tegrastats
kill $tegrastats_pid


"~/cpesgafiles/guppyout/guppy_output.txt"