package OCR;

import java.util.ArrayList;

import net.ricecode.similarity.LevenshteinDistanceStrategy;
import net.ricecode.similarity.SimilarityStrategy;
import net.ricecode.similarity.StringSimilarityService;
import net.ricecode.similarity.StringSimilarityServiceImpl;

public class StringSimilarityComparer {
	
	public static String compare(String input, ArrayList<String> list) {
		double maxScore = 0.0;
		int maxIndex=0;

		SimilarityStrategy strategy = new LevenshteinDistanceStrategy();
		StringSimilarityService service = new StringSimilarityServiceImpl(strategy);
		
		for(String element : list) {
			double score = service.score(element, input);
			if(score>maxScore) {
				maxScore = score;
				maxIndex = list.indexOf(element);
			}
		}
		return list.get(maxIndex);
	}
	


}
