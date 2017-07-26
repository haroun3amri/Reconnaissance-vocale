function [y]=filtre(dir)
[x,fs] = audioread(dir);
y=specsub(x,fs);
y=FiltrePassBas(y,fs);
audiowrite('result.wav',y,fs);
