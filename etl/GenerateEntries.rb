sequence = ('a'..'z').to_a;
points = [1,3,3,2,1,4,2,4,1,8,5,1,3,1,1,3,10,1,1,1,1,4,4,8,4,10]

for i in 0..sequence.length - 1 do
	puts "[\'#{sequence[i]}\'] = #{points[i]}"
end