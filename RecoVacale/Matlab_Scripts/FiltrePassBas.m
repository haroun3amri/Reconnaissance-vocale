function [y]=FiltrePassBas(x,fs)
cutoff = 500/(fs/2); % Set the frequency at which the attenuation begins.
order = 4;
d = designfilt('lowpassfir','CutoffFrequency',cutoff,'FilterOrder',order)
y = filter(d,x); % o is the filtered version of y



