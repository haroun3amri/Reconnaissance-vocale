clear all;
close all;
%Lire le fichier audio
[x,fs] = audioread('Stage/2.wav');
y=specsub(x,fs);
y=FiltrePassBas(y,fs);
audiowrite('result.wav',y,fs);
plot(x);
hold on
plot(y);
legend('old signal','new signal');